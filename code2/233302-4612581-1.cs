    var searchValue = textEdit1.Text;
    
    				var parser = new QueryParser(version, "FullName", analyzer);
    				parser.SetLocale(new CultureInfo("ru-RU"));
    				Query query = parser.Parse(searchValue);
    				var indexSearcher = new IndexSearcher(directory, true);
    
    				var docs = indexSearcher.Search(query, 10);
    				lblSearchTotal.Text = string.Format(totalPattern, docs.totalHits, organizations.Count() + orders.Count);
    				resultPanel.Controls.Clear();
    				foreach (var found in docs.scoreDocs)
    				{
    					var document = indexSearcher.Doc(found.doc);
    					var objectId = document.Get("Id");
    					var objectType = document.Get("ObjectTypeInvariantName");
    
    					if (resultPanel.Controls.Count > 0)
    					{
    						var labelSeparator = CreateSeparatorLabelControl();
    						resultPanel.Controls.Add(labelSeparator);
    					}
    					var labelCard = CreateFoundLabelControl();
    					resultPanel.Controls.Add(labelCard);
    
    					var organization = organizations.Where(o => o.ID.ToString() == objectId).FirstOrDefault();
    					if (organization != null)
    					{
    						labelCard.Text = string.Format("<b>{0}</b></br>{1}", organization.AccountNumber, organization.FullName);
    						labelCard.Tag = organization;
    						//labels[count].Text = string.Format("<b>{0}</b></br>{1}", organization.AccountNumber, organization.FullName);
    						//labels[count].Visible = true;
    					}
    					else
    					{
    						labelCard.Text = string.Format("Найден объект типа '{0}' с идентификатором '{1}'", objectType, objectId);
    						labelCard.Tag = mainForm.GetObject(objectType, objectId); 
    					}
    					labelCard.Visible = true;
    					//count++;
    				}
