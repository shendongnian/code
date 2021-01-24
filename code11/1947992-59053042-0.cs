        // declare the method as Async using a return type of 'Task'
        private async Task PopulateName()
        {
            try
            {
                string data1 = WebOp.baseUrl1 + "" + Const.action + "=" + Const.productByCategory + "" +
                 "&" + Const.category_id + "=" + category_id;
                // explicitly await the Task...
                await System.Threading.Tasks.Task.Run(() =>
                {
                    RunOnUiThread(() => { progressDialog.Show(); });
                    WebOp webOp = new WebOp();
                    String str = webOp.doPost1(data1, this);
                    JObject jobj = JObject.Parse(str);
                    string status = jobj[Const.status].ToString();
                    if (status.Equals(Const.success))
                    {
                        try
                        {
                            string data = jobj[Const.data].ToString();
                            myDto = JsonConvert.DeserializeObject<List<ProductDto>>(data)[0];
                            name = myDto.thecategory_name;
                            Console.WriteLine("Check value:" + name); //returns the value fine
                            RunOnUiThread(() =>
                            {
                                progressDialog.Dismiss();
                            });
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e + "");
                            RunOnUiThread(() => { progressDialog.Dismiss(); });
                        }
                    }
                    else
                    {
                        RunOnUiThread(() =>
                        {
                            progressDialog.Dismiss();
                        });
                    }
                }).ConfigureAwait(false);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1 + "");
            }
            Console.WriteLine("Check again:" + name); //returns nothing
        }
