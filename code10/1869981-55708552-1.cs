    if (borrow.Button.Equals("Retourner"))
			{
				foreach (SubscriberBookEntity subscriberBookEntity in subscriberBookEntityList)
				{
                    foreach(Book borrowBook in borrow.Library.BookList)
                    {
                        if(borrowBook.IsChecked && borrowBook.Id == subscriberBook.BookId && subscriberBook.SubscriberId == borrow.SelectedSubscriberId)
                        {
                            subscriberBook.DateRetour = DateTime.Now;
                            Manager.UpdateBorrow(subscriberBook);
                        }
                    }
				}
				List<SubscriberBookEntity> SubscriberBookEntityList = Manager.GetAllBorrow();
			}
