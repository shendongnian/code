 C#
public class TopicDTO()
{
    public int NumberOfTopics { get; set; }
}
Then in your query:
 C#
var result = _context.Subjects
                     .Include(s => s.Course)
                     .Include(t => t.Topics)
                     .Select(x => new TopicDTO() 
                      {
                          NumberOfTopics = x.Topics.Count()
                      });
return View(await result.ToListAsync());
