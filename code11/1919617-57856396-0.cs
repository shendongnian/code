    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Globalization;
    namespace WindowsFormsApplication52
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.txt";
            public Form1()
            {
                InitializeComponent();
                FILEITEM.ParseFile(FILENAME, this);
                FILEITEM.MakeTree(FILEITEM.files, null, treeView1, 0);
                treeView1.ExpandAll();
            }
        }
        public class FILEITEM
        {
            const string DIRECTORY_OF = "Directory of";
            const string REGEX_DATE_PATTERN = @"\d{2}/\d{2}/\d{4}\s\s\d{2}:\d{2}\s[AP]M";
            const string REGEX_FILENAME_PATTERN = @"[^\s]+";
            public static List<FILEITEM> files = new List<FILEITEM>();
            public string[] folder { get; set; }
            public string filename { get; set; }
            public DateTime time { get; set; }
            public static void ParseFile(string filename, Form1 form1)
            {
                CultureInfo info = CultureInfo.InvariantCulture;
                StreamReader reader = new StreamReader(filename);
                string[] directory = null;
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(DIRECTORY_OF))
                    {
                        directory = line.Substring(line.IndexOf(DIRECTORY_OF) + DIRECTORY_OF.Length).Trim().Split(new char[] {'\\'}).ToArray();
                    }
                    else
                    {
                        Match dateMatch = Regex.Match(line, REGEX_DATE_PATTERN);
                        if (dateMatch.Success && !line.Contains("<DIR>"))
                        {
                            Match filenameMatch = Regex.Match(line.Trim(), REGEX_FILENAME_PATTERN, RegexOptions.RightToLeft);
                            FILEITEM newFileItem = new FILEITEM() { folder = directory, filename = filenameMatch.Value, time = DateTime.ParseExact(dateMatch.Value, "dd/MM/yyyy  hh:mm tt", info) };
                            files.Add(newFileItem);
                        }
                    }
                }
            }
            public static void MakeTree(List<FILEITEM> files, TreeNode node, TreeView treeview1, int index)
            {
                TreeNode childNode = null;
                var groups = files.Where(x => x.folder.Length > index).GroupBy(x => x.folder[index]).ToList();
                foreach(var group in groups)
                {
                    childNode = new TreeNode(group.Key);
                    if (node == null)
                    {
                        treeview1.Nodes.Add(childNode);
                    }
                    else
                    {
                        node.Nodes.Add(childNode);
                    }
                    foreach (FILEITEM item in group)
                    {
                        if (item.folder.Length - 1 == index)
                        {
                            TreeNode fileNode = new TreeNode(string.Join(",", new string[] { item.filename, item.time.ToLongDateString() + "  " + item.time.ToLongTimeString() }));
                            childNode.Nodes.Add(fileNode);
                        }
                    }
                    MakeTree(group.ToList(), childNode, null, index + 1);
                }
            }
        }
    }
