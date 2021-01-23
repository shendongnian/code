    public string ProxyUpdateTask(Task myTask, string strWorkProduct)
        {
            var message = @"<span style=""color:green;"">SUCCESS</span>";
            const string errPrefix = @"<span style=""color:red;"">ERROR</span>";
            
            var toUpdate = new DynamicJsonObject();
            
            long oid;
            Int64.TryParse(myTask.ObjectId, out oid);
            toUpdate["WorkProduct"] = String.Format("/hierarchicalrequirement/{0}", myTask.UserStoryId);
            try
            {
                var result = _restApi.Update("task", oid, toUpdate);
                if (!result.Success) 
                    message = String.Format(@" {2} updating (ObjectID={0}) failed. {1}", myTask.ObjectId, result.Errors, errPrefix);
            }
            catch (WebException ex)
            {
                message = String.Format(" {0} - {1}", errPrefix, ex.Message);
            }
            catch (Exception ex)
            {
                message = String.Format(" {0} - {1}", errPrefix, ex.Message);
            }
            return message;
            
        }
