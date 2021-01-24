        private void button1_Click(object sender, EventArgs e)
        {
            string[] names = { "Mathew", "Mark", "Luke", "John" };
            int index = Array.IndexOf(names, "Luke");
            Debug.Print(index.ToString());
            //Prints 2
        }
