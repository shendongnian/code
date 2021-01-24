        [ResponseType(typeof(Person))]
		public async Task<IHttpActionResult> GetPerson(string id)
		{
			Person p = new Person();
			try {
				p = await db.Person.FindAsync(id);
				
				if(p == null) {
					throw new Exception("Person " + id + " not found.");
				}
                 
				var exams = db.Exam.FindAsync(p.IDENTITY);
				if(exams != null) {
                    p.Exams = new Exam[exams.Count()];
					p.Exams = exams.ToArray();
				}
			}
			catch(Exception e) {
				//log exception here, is it just a person not found or somehting else?
				return NotFound(); 
			}
			return OK(p);
		}
