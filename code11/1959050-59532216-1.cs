    public class ProjectBController : Controller  
    {  
        //your Hosted Base URL
        string Baseurl = "http://192.168.90.1:85/";      
		// GET: Student
        public async Task<ActionResult> GetStudents()  
        {  
            List<Student> StudentInfo = new List<Student>();  
              
            using (var client = new HttpClient())  
            {  
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);  
  
                client.DefaultRequestHeaders.Clear();  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                  
                //Sending request to find web api REST service resource GetDepartments using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/ProjectA/GetDepartments");  
  
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)  
                {  
   
					var ObjResponse = Res.Content.ReadAsStringAsync().Result;  
                    StudentInfo = JsonConvert.DeserializeObject<List<Student>>(ObjResponse);  
  
                }  
                //returning the student list to view  
                return View(StudentInfo);  
            }  
        }  
    }  
    public class Student
    {
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
    }
