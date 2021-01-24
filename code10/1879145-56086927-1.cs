using System.Linq;
using MongoDB.Entities;
namespace StackOverflow
{
    public class Meal : Entity
    {
        public string Name { get; set; }
        public Many<MealRequest> Requests { get; set; }
        public Meal() => this.InitOneToMany(() => Requests);
    }
    public class MealRequest : Entity
    {
        public One<Meal> Meal { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("retaurant-test");
            var meal = new Meal { Name = "pollo e funghi pasta" };
            meal.Save();
            var mealRequest = new MealRequest
            {
                Name = "pasta meal",
                Meal = meal.ToReference()
            };
            mealRequest.Save();
            meal.Requests.Add(mealRequest);
            var chickenMushroomPastaMealRequests = DB.Collection<MealRequest>()
                                                     .Where(mr => mr.Meal.ID == meal.ID)
                                                     .ToList();
            var resMealRequests = meal.Requests.Collection().ToList();
            var resMeal = resMealRequests.First().Meal.ToEntity();
        }
    }
}
if it must be done using the official driver, i'd do it using linq as follows:
var mealrequests = (from m in repo.Meals.AsQueryable()
                    join mr in repo.MealRequests.AsQueryable() on m.ID equals mr.MealID into requests
                    from r in requests
                    select r).ToList();
