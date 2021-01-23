    List<Categories> categoriess;
            private void Buscar()
            {
                try
                {
                    categoriess = Contexto.Categories.ToList();
                    categoriess = categoriess.Where(n => n.CategoryID >= Convert.ToInt32(txtCatID.Text) && n.CategoryID <= Convert.ToInt32(txtCatID1.Text) && (n.CategoryName.Contains(txtCatName.Text)) ).ToList();
