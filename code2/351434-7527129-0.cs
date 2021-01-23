        [Test]
        public void Sort()
        {
            string[] files = Directory
                .GetFiles(fbdialog.SelectedPath, "*", SearchOption.AllDirectories);
            Array.Sort(files, new EmpNoFileComparer());
        }
        private class EmpNoFileComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                string empNoX = Path.GetFileName(x).Split('-')[1];
                string empNoY = Path.GetFileName(y).Split('-')[1];
                return empNoX.CompareTo(empNoY);
            }
        }
