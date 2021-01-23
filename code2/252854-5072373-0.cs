    private void OnUpdating(object sender, LinqDataSourceUpdateEventArgs e)
        {
            var newCategory = (Category)e.NewObject;
            var oldCategory = (Category)e.OriginalObject;
            var repository = new Repository<CategoriesToWebsite>();
            var ctw = repository.GetAll().Where(x => x.CategoryId == newCategory.Id);
            foreach (var listItem in WebsiteList.Items.Cast<ListItem>())
            {
                var current = ctw.FirstOrDefault(x => x.WebsiteId == Convert.ToInt32(listItem.Value));
                //current categoriesToWebsite exists
                if (current != null)
                {
                    //if not selected, remove
                    if (!listItem.Selected)
                        repository.Delete(current);
                }
                //does not exist
                else
                {
                    //if selected, add
                    if (listItem.Selected)
                        repository.Save(new CategoriesToWebsite()
                            {
                                CategoryId = newCategory.Id,
                                WebsiteId = Convert.ToInt32(listItem.Value)
                            }
                        );
                }
            }
            UnitOfWork.Current.SubmitChanges();
        }
