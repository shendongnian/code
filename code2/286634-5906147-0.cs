    public Request SearchById(int id)
            {
               using(Model.ModelContainer cont = new Model.ModelContainer())
               {
                    return cont.Requests.Where(req => req.ReqId == id).FirstOrDefault();
               }
            }
