    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using ClassLibrary;
    using System.Xml;
    using System.Diagnostics;
    using System.IO;
    using System.Xml.Linq;
    namespace WindowsFormsApplication
    {
        public partial class HideRestoreNodesForm : Form
        {
            private List<RemovedTreeNode> _removedNodes = new List<RemovedTreeNode>();
            public HideRestoreNodesForm()
            {
                InitializeComponent();
                //AddNodesToTree();
            }
            private void searchButton_Click(object sender, EventArgs e)
            {
                TreeNode[] foundNodes = treeView1.Nodes.Find("NameOfNodeToFind", true);
                if(foundNodes.Length > 0)
                {
                    TreeNode foundNode = foundNodes[0];
                    HideNodes(treeView1.Nodes, foundNode);
                }
            }
            private void HideNodes(TreeNodeCollection nodes, TreeNode visibleNode)
            {
                List<TreeNode> nodesToRemove = new List<TreeNode>();
                foreach (TreeNode node in nodes)
                {
                    if (!AreNodesRelated(node, visibleNode))
                    {
                        _removedNodes.Add(new RemovedTreeNode() { RemovedNode = node, ParentNode = node.Parent, RemovedNodeIndex = node.Index });
                        nodesToRemove.Add(node);
                    }
                    else
                    {
                        HideNodes(node.Nodes, visibleNode);
                    }
                }
                foreach (TreeNode node in nodesToRemove)
                    node.Remove();
            }
            private bool AreNodesRelated(TreeNode firstNode, TreeNode secondNode)
            {
                if (!IsNodeAncestor(firstNode, secondNode) && !IsNodeAncestor(secondNode, firstNode) && firstNode != secondNode)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            private bool IsNodeAncestor(TreeNode nodeToCheck, TreeNode descendantNode)
            {
                TreeNode parentNode = descendantNode.Parent;
                while (parentNode != null)
                {
                    if (parentNode == nodeToCheck)
                    {
                        return true;
                    }
                    else
                    {
                        parentNode = parentNode.Parent;
                    }
                }
                return false;
            }
            private void restoreNodes_Click(object sender, EventArgs e)
            {
                RestoreNodes();
            }
            private void RestoreNodes()
            {
                _removedNodes.Reverse();
                foreach (RemovedTreeNode removedNode in _removedNodes)
                {
                    if (removedNode.ParentNode == null)
                        treeView1.Nodes.Add(removedNode.RemovedNode);
                    else
                        removedNode.ParentNode.Nodes.Insert(removedNode.RemovedNodeIndex ,removedNode.RemovedNode);
                }
                _removedNodes.Clear();
            }
        }
        public class RemovedTreeNode
        {
            public TreeNode RemovedNode { get; set; }
            public int RemovedNodeIndex { get; set; }
            public TreeNode ParentNode { get; set; }
        }
    }
