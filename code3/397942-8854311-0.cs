                entry.Publishers = new EntityCollection<Publisher>();
                foreach (Publisher item in this.publishersLst.SelectedItems)
                {
                    entry.Publishers.Add(item);
                }
