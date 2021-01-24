    using System;
    using System.Collections.Generic;
    using UnityEditor.Callbacks;
    using UnityEditor.IMGUI.Controls;
    using UnityEngine;
    
    
    namespace UnityEditor.TreeViewExamples
    {
    
        class CustomHeightWindow : EditorWindow
        {
            [NonSerialized] bool m_Initialized;
            [SerializeField] TreeViewState m_TreeViewState; // Serialized in the window layout file so it survives assembly reloading
            SearchField m_SearchField;
            CustomHeightTreeView m_TreeView;
            MyTreeAsset m_MyTreeAsset;
            SimpleTreeView simple_m_TreeView;
    
            private GUIStyle currentStyle = null;
            static int numofconversations = 10;
            static int oldnumofconversations;
    
            [MenuItem("TreeView Examples/Custom Row Heights")]
            public static CustomHeightWindow GetWindow()
            {
                var window = GetWindow<CustomHeightWindow>();
                window.titleContent = new GUIContent("Custom Heights");
                window.Focus();
                window.Repaint();
    
                oldnumofconversations = numofconversations;
    
                return window;
            }
    
            [OnOpenAsset]
            public static bool OnOpenAsset(int instanceID, int line)
            {
                var myTreeAsset = EditorUtility.InstanceIDToObject(instanceID) as MyTreeAsset;
                if (myTreeAsset != null)
                {
                    var window = GetWindow();
                    window.SetTreeAsset(myTreeAsset);
                    return true;
                }
                return false; // we did not handle the open
            }
    
            void SetTreeAsset(MyTreeAsset myTreeAsset)
            {
                m_MyTreeAsset = myTreeAsset;
                m_Initialized = false;
            }
    
            Rect treeViewRect
            {
                get { return new Rect(20, 70, position.width - 40, position.height - 100); }
            }
    
            Rect toolbarRect
            {
                get { return new Rect(20f, 10f, position.width - 40f, 20f); }
            }
    
            Rect bottomToolbarRect
            {
                get { return new Rect(20f, position.height - 18f, position.width - 40f, 16f); }
            }
    
            void InitIfNeeded()
            {
                if (!m_Initialized)
                {
                    // Check if it already exists (deserialized from window layout file or scriptable object)
                    if (m_TreeViewState == null)
                        m_TreeViewState = new TreeViewState();
    
                    var treeModel = new TreeModel<MyTreeElement>(GetData());
                    m_TreeView = new CustomHeightTreeView(m_TreeViewState, treeModel);
    
                    m_SearchField = new SearchField();
                    m_SearchField.downOrUpArrowKeyPressed += m_TreeView.SetFocusAndEnsureSelectedItem;
                    
                    m_Initialized = true;
                }
            }
    
            IList<MyTreeElement> GetData()
            {
                if (m_MyTreeAsset != null && m_MyTreeAsset.treeElements != null && m_MyTreeAsset.treeElements.Count > 0)
                    return m_MyTreeAsset.treeElements;
    
                // generate some test data
                return MyTreeElementGenerator.GenerateRandomTree(numofconversations);
            }
    
            void OnSelectionChange()
            {
                if (!m_Initialized)
                    return;
    
                var myTreeAsset = Selection.activeObject as MyTreeAsset;
                if (myTreeAsset != null && myTreeAsset != m_MyTreeAsset)
                {
                    m_MyTreeAsset = myTreeAsset;
                    m_TreeView.treeModel.SetData(GetData());
                    m_TreeView.Reload();
                }
            }
    
            void OnGUI()
            {
                if(oldnumofconversations != numofconversations)
                {
                    m_Initialized = false;
                    oldnumofconversations = numofconversations;
                }
    
                InitIfNeeded();
    
                SearchBar(toolbarRect);
                DoTreeView(treeViewRect);
                BottomToolBar(bottomToolbarRect);
                DoFields();
    
                DoTreeView();
            }
    
            void SearchBar(Rect rect)
            {
                m_TreeView.searchString = m_SearchField.OnGUI(rect, m_TreeView.searchString);
            }
    
            void DoTreeView(Rect rect)
            {
                m_TreeView.OnGUI(rect);
            }
    
            void BottomToolBar(Rect rect)
            {
                GUILayout.BeginArea(rect);
    
                using (new EditorGUILayout.HorizontalScope())
                {
                    var style = "miniButton";
                    if (GUILayout.Button("Expand All", style))
                    {
                        m_TreeView.ExpandAll();
                    }
    
                    if (GUILayout.Button("Collapse All", style))
                    {
                        m_TreeView.CollapseAll();
                    }
                }
    
                GUILayout.EndArea();
            }
    
            void DoFields()
            {
                DrawBox(new Rect(20, 35, position.width - 40, 30),"", Color.white);
                numofconversations = EditorGUI.IntField(new Rect(187, 43, 50, 15), numofconversations);
                GUI.Label(new Rect(37, 41, 150, 15), "Number of conversations");
            }
    
            void DrawBox(Rect position, string content, Color color)
            {
                Color oldColor = GUI.color;
    
                GUI.color = color;
                GUI.Box(position, content);
    
                GUI.color = oldColor;
            }
    
            void DoTreeView()
            {
                
            }
        }
    }
