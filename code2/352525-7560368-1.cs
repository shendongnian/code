        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = GetProducts(textBox1.Text);
            listBox1.ValueMember = "Id";
            listBox1.DisplayMember = "Name";
        }
       
        List<Product> GetProducts(string keyword)
        {
            IQueryable q = from p in db.GetTable<Product>()
                           where p.Name.Contains(keyword)
                           select p;
            List<Product> products = q.ToList<Product>();
            return products;
        }
