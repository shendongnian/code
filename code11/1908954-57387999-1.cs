        public class Car
        {
           public int Id { get; set; }
           public string CarName { get; set; }
        }
        [ServiceFilter(typeof(ValidationFilter))]
        [HttpPut("{id}")]
        public Car Put(int id, [FromBody] Car car)
        {
         // the stuff you want
        }
