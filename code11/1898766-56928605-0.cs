IViewModel CreateViewModel(IProduct product)
{
    var vmType = Assembly.getTypes().SingleOrDefault(x => x.Name == $"{product.GetType().Name}ViewModel");
    // Create instance of vmType and perform mapping of properties between product and vm using reflection based on name convention. Automapper can do this for you as well.
    }
