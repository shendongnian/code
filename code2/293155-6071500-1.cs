        private void DebugObject(object obj)
        {
            string printString = "";
            foreach (System.Reflection.PropertyInfo pi in obj.GetType().GetProperties())
            {
                printString += pi.Name + " : " + pi.GetValue(obj, new object[0]) + "\n" ;
            }
            MessageBox.Show(printString);
        }
