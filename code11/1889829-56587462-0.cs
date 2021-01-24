    if (this.ModelState.IsValid)
                {
                    Task<bool> task = this.TryUpdateModelAsync(Model, Model.GetType(), "");
                    task.Wait();
                    if (!task.Result)
                        throw new Exception("TxServerController.TxMap: TryUpdateModelAsync failed");
                }
                this.ModelState.Clear();
