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
