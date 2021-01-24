       public class Test
        {
            private void LoadFiles(string dir, TreeNode td)
            {
                string[] Files = Directory.GetFiles(dir, "*.pdf");
                Files = Files.Select(x => new MySort(x)).OrderBy(x => x).Select(x => x.filename).ToArray();
                // Loop through them to see files  
                foreach (string file in Files)
                {
                    FileInfo fi = new FileInfo(file);
                    TreeNode tds = td.Nodes.Add(fi.Name);
                    tds.Tag = fi.FullName;
                    tds.ImageIndex = 1;
                    tds.StateImageIndex = 1;
                    tds.SelectedImageIndex = 1;
                }
            }
        }
        public class MySort : IComparable
        {
            private string[] splitvalues { get; set; }
            public string filename { get; set; }
            public MySort(string filename)
            {
                this.filename = filename;
                splitvalues = filename.Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            public int CompareTo(object other)
            {
                MySort otherMySort = (MySort)other;
                int min = Math.Min(this.splitvalues.Length, otherMySort.splitvalues.Length);
                for (int i = 0; i < min; i++)
                {
                    string a = this.splitvalues[i];
                    string b = otherMySort.splitvalues[i];
                    if (a != b)
                    {
                        int numberA = 0;
                        int numberB = 0;
                        if (int.TryParse(a, out numberA))
                        {
                            if (int.TryParse(b, out numberB))
                            {
                                int z = numberA.CompareTo(numberB);
                                //a & b are numbers
                                return numberA.CompareTo(numberB);
                            }
                            else
                            {
                                //a number b string
                                return -1;
                            }
                        }
                        else
                        {
                            if (int.TryParse(b, out numberB))
                            {
                                //a string b number
                                return 1;
                            }
                            else
                            {
                                // a string b string
                                return a.CompareTo(b);
                            }
                        }
                    }
                }
                return splitvalues.Length.CompareTo(otherMySort.splitvalues.Length);
            }
        }
