        public void PrintList(IList<object> list)
        {
            string printString = "List Elements";
            foreach (object o in list)
            {
                // Add the fields you want to show here
                printString += "\n" + o.ToString();
            }
            MessageBox.Show(printString);
        }
