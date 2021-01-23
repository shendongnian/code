            var list = new List<ProductLine>(5);
            list.Add(new ProductLine { Amount = list.Count });
            list.Add(new ProductLine { Amount = list.Count });
            list.Add(new ProductLine { Amount = list.Count });
            list.Add(new ProductLine { Amount = list.Count });
            list.Add(new ProductLine { Amount = list.Count });
            var bs = new BindingSource {DataSource = list };
            dataGridView1.DataSource = bs;
