        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Person> Post([FromBody] PersonName NameObject)
        {
            string Name = NameObject.Name;
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }
            Person NewPerson = P_API.AddPerson(Name); // Debugger confirms object was created successfully
                                                      // Fails to return here
            return NewPerson; //  CreatedAtAction("Created", new { id = NewPerson.Id, name = NewPerson.Name }, NewPerson);
        }
