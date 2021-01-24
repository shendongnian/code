        var data = {
            name: 'John'          
        };     
        var response = fetch('Home/ResultPage', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(data)
        });
 
 
        [HttpPost]
        public void ResultPage([FromBody]Parameter parameter)
        {
            //code here
        }
        public class Parameter
        {
           public string name { get; set; }
        }
