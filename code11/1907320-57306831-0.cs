public class Project
{
   public int ProjectID { get; set; }
   public string ProjectName{ get; set; }
   public string ProjectLocation{ get; set; }
   public virtual List<People> ListOfPeople { get; set; }
}
Then in your controller or view, you could navigate to the properties of the objects in that list;
// this will give the first name of the first person on the first project
db.Project.FirstOrDefault().ListOfPeople.FirstOrDefault().FirstName;
For your create action in your controller, since it's a new Project, it doesn't have any People in it. Hence you will need to manually populate that list. To populate it, since you only need specific people, I suggest to use a checkbox or multiple input fields (aided with javascript).
The ListOfPeople can be populated by having a form element;
<input name="ListOfPeople[1].PeopleId" value="1"/>
<input name="ListOfPeople[1].FirstName" value="Mark"/>
<input name="ListOfPeople[1].LastName" value="Jacob"/>
<input name="ListOfPeople[1].PeopleId" value="2"/>
<input name="ListOfPeople[2].FirstName" value="Red"/>
<input name="ListOfPeople[2].LastName" value="Wandersee"/>
When you submit the form, the values will be bound to the Project model's ListOfPeople. Then that's the time you will need to loop through it and create a ProjectPerson (junction) record which determines where this person belongs to.
foreach(var i in model.ListOfPeople){
   ProjectPerson pp = new ProjectPerson();
   ... // do property assignment
   db.ProjectPerson.add(pp);
}
