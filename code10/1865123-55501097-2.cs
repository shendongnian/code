     foreach(var person in people)
        {
            <button onclick="@(async () => await Delete(person.Id))">Delete</button>
        }
    
    @functions {
      // Get a list of People.
      List<Person> People ;
    protected override async Task OnParametersSetAsync()
    {
        People = await this.PersonRepository.getAll();
    }
 
    async Task Delete(Guid personId)
    {
         await this.PersonRepository.Delete(personId);
    }
    }
