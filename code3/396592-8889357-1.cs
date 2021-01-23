    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web.UI;
    using System.IO;
    using Telerik.Web.UI;
    //extensions we have pics for
    private readonly string[] _knownExtensions = new[] { "csv", "doc", "docx", "gif", "html", "jpg", "pdf", "png", "txt", "xls", "xlsx", "xml" }; 
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       {
          if (Session["nodes"] != null && ((List<string>)Session["nodes"]).Count > 0)
          {
             foreach (string nod in (List<string>)Session["nodes"])
             {
                AddNode(nod);
             }
          }
          else
          {
             AddNode(ConfigurationManager.AppSettings["LinkDocumentStartPath"]);
          }
       }
    }
    private void AddNode(string rootpath)
    {
       Directory.GetDirectories(rootpath);
       inpPath.Value = rootpath;
       //won't get this far if it fails the first check
       var dirNode = new RadTreeNode(rootpath)
       {
          Value = rootpath,
          ImageUrl = "~/Content/Images/folder.png",
          Expanded = true,
          ExpandMode = TreeNodeExpandMode.ServerSideCallBack
       };
       dirNode.Attributes.Add("isFile", "false");
       RadTreeView1.Nodes.Add(dirNode);
    }
    protected void RadTreeView1_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
       BindTreeToDirectory(e.Node.Value, e.Node);
    }
    private void BindTreeToDirectory(string path, RadTreeNode parentNode)
    {
       //get directories
       string[] directories = Directory.GetDirectories(path);
       foreach (string directory in directories)
       {
          var dirNode = new RadTreeNode(Path.GetFileName(directory))
          {
             Value = path + "/" + Path.GetFileName(directory),
             ImageUrl = "~/Content/Images/folder.png",
             ExpandMode = TreeNodeExpandMode.ServerSideCallBack
          };
          dirNode.Attributes.Add("isFile","false");
          parentNode.Nodes.Add(dirNode);
       }
       //get files in directory
       string[] files = Directory.GetFiles(path);
       foreach (string file in files)
       {
          var node = new RadTreeNode(Path.GetFileName(file));
          node.Attributes.Add("isFile", "true");
          //get extension
          string extension = Path.GetExtension(file);
          if (!string.IsNullOrEmpty(extension))
          {
             extension = extension.ToLower().TrimStart('.');
          }
          //choose an image for the extension
          if (Array.IndexOf(_knownExtensions, extension) > -1)
          {
             node.ImageUrl = "~/Content/Images/" + extension + ".png";
          }
          else
          {
             node.ImageUrl = "~/Content/Images/unknown.png";
          }
          parentNode.Nodes.Add(node);
       }
    }
    //go to a new directory
    protected void btnGo_Click(object sender, EventArgs e)
    {
       string nod = inpPath.Value.Trim();
       if (!string.isNullOrEmpty(nod))
       {
          var nodeslst = new List<string>();
          if (Session["nodes"] != null)
          {
             nodeslst = (List<string>) Session["nodes"];
          }
          else
          {
             //session has expired - get nodes from radtree
             nodeslst.AddRange(from RadTreeNode rtn in RadTreeView1.Nodes select rtn.Value);
          }
          if (nodeslst.Contains(nod, StringComparer.OrdinalIgnoreCase) == false)
          {
             AddNode(nod);
             nodeslst.Add(nod);
          }
          Session["nodes"] = nodeslst;
       }
    }
