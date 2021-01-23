        public void PrintList(IList<object> list)
        {
            string printString = "List Elements";
            foreach (object o in list)
            {
                printString += "\n" + o.ToString();
            }
            MessageBox.Show(printString);
        }
