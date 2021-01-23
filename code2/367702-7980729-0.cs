    using System;
    using System.Data;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace app
    {
        public partial class Form1 : Form
        {
            DataTable urls = new DataTable();
            public Form1()
            {
                InitializeComponent();
            }
            //Fill your uri's and bind to a data grid.
            void InitTable()
            {
                //Silly logic to simulate your scenario.
                urls = new DataTable();
                urls.Columns.Add(new DataColumn("Srl", typeof(string)));
                urls.Columns.Add(new DataColumn("Urls", typeof(Uri)));
                urls.Columns.Add(new DataColumn("Result", typeof(string)));
    
                DataRow dr = urls.NewRow();
                dr["Srl"] = "1";
                dr["Urls"] = new Uri("http://www.microsoft.com");
                dr["Result"] = string.Empty;
                urls.Rows.Add(dr);
                dr = urls.NewRow();
                dr["Srl"] = "2";
                dr["Urls"] = new Uri("http://www.google.com");
                dr["Result"] = string.Empty;
                urls.Rows.Add(dr);
                dr = urls.NewRow();
                dr["Srl"] = "3";
                dr["Urls"] = new Uri("http://www.stackoverflow.com");
                dr["Result"] = string.Empty;
                urls.Rows.Add(dr);
                urls.AcceptChanges();
            }
            void UpdateResult()
            {
                dataGridView1.DataSource = urls;
            }
    
            //Important
            // This example will freeze UI. You can avoid this while implementing
            //background worker or pool with some event synchronization. I haven't covered those area since
            //we are addressing different issue. Let me know if you would like to address UI freeze
            //issue. Or can do it your self.
            private void button1_Click(object sender, EventArgs e)
            {            
                //Create array for Task to parallelize multiple download.
                var tasks = new Task<string[]>[urls.Rows.Count];
                //Initialize those task based on number of Uri's
                for(int i=0;i<urls.Rows.Count;i++)
    	        {
                    int index = i;//Do not change this. This is to avoid data race
                    //Assign responsibility and start task.
                    tasks[index] = new Task<string[]>(
                            () => checkSite(
                                new TaskInput(urls.Rows[index]["Urls"].ToString(), urls.Rows[index]["Srl"].ToString())));
                    tasks[index].Start();
    		        
    	        }
                //Wait for all task to complete. Check other overloaded if interested.
                Task.WaitAll(tasks);
                
                //block shows how to access result from task
                foreach (var item in tasks)
    	        {
    		       DataRow[] rows=urls.Select("Srl='"+item.Result[2]+"'");
                   foreach (var row in rows)
    	                  row["Result"]=item.Result[0]+"|"+item.Result[1];
                }
                UpdateResult();
            }
            //This is dummy method which in your case 'Check Site'. You can have your own
            string[] checkSite(TaskInput input)
            {
                string[] response = new string[3];
                if (input != null)
                {
                    try
                    {
                        WebResponse wResponse = WebRequest.Create(input.Url).GetResponse();
    
                        response[0] = wResponse.ContentLength.ToString();
                        response[1] = wResponse.ContentType;
                        response[2] = input.Srl;
                        return response;
                    }
                    catch (Exception he)
                    {
                        response[0] = "catch";
                        response[1] = he.Message;
                       response[2] = input.Srl;
                        return response;
                    }
                }
                response[0] = "catch";
                response[1] = "No URL entered";
                response[2] = input.Srl;
                return response;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                InitTable();
                UpdateResult();
            }
        }
        //Supply custom object for simplicity
        public class TaskInput
        {
           public TaskInput(){}
           public TaskInput(string url, string srl)
            {
                Url = url;
                Srl = srl;
            }
            public string Srl { get; set; }
            public string Url { get; set; }
        }
    }
