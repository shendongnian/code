    directory = new RAMDirectory();
    			analyzer = new StandardAnalyzer(version, new Hashtable());
    			var indexWriter = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED);
    			using (var session = sessionFactory.OpenStatelessSession())
    			{
    				organizations = session.CreateCriteria(typeof(Organization)).List<Organization>();
    				foreach (var organization in organizations)
    				{
    					var document = new Document();
    					document.Add(new Field("Id", organization.ID.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS));
    					document.Add(new Field("FullName", organization.FullName, Field.Store.NO, Field.Index.ANALYZED_NO_NORMS));
    					document.Add(new Field("ObjectTypeInvariantName", typeof(Organization).FullName, Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS));
    					indexWriter.AddDocument(document);
    				}
    
    				var persistentType = typeof(Order);
    				var classMetadata = DbContext.SessionFactory.GetClassMetadata(persistentType);
    
    
    				var properties = new List<PropertyInfo>();
    				for (int i = 0; i < classMetadata.PropertyTypes.Length; i++)
    				{
    					var propertyType = classMetadata.PropertyTypes[i];
    					if (propertyType.IsCollectionType || propertyType.IsEntityType) continue;
    					properties.Add(typeof(Order).GetProperty(classMetadata.PropertyNames[i]));
    				}
    
    				orders = session.CreateCriteria(typeof(Order)).List<Order>();
    				var idProperty = typeof(Order).GetProperty(classMetadata.IdentifierPropertyName);
    
    				foreach (var order in orders)
    				{
    					var document = new Document();
    					document.Add(new Field("Id", idProperty.GetValue(order, null).ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS));
    					document.Add(new Field("ObjectTypeInvariantName", typeof(Order).FullName, Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS));
    					foreach (var property in properties)
    					{
    						var value = property.GetValue(order, null);
    						if (value != null)
    						{
    
    							document.Add(new Field(property.Name, value.ToString(), Field.Store.NO, Field.Index.ANALYZED_NO_NORMS));
    						}
    					}
    					indexWriter.AddDocument(document);
    				}
    				indexWriter.Optimize(true);
    				indexWriter.Commit();
    				return indexWriter.GetReader();
    			}
