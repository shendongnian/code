Actions ac = (Actions)Enum.Parse(typeof(Actions), Console.ReadLine());
// THen use switch on ac.
    switch (ac)
    {
        case Actions.add:
            // do something here
            break;
        case Actions.delete:
            // do something here
            break;
        default:
            throw new ApplicationException("Error");
    }
Enums, by default, starts with 0. If you want to start with a 1, then assign the int values
public enum Actions
        {
             delete = 1,
             add = 2,
             edit = 3
        };
