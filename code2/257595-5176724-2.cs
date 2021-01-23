    class TodoPresenter
    {
        public void Save()
        {
           using (TodoService service = new TodoService())
           {
               Todo item = null;
               // ...
               service.Save(item);
               service.SubmitChanges();           
           }
        }
    }
