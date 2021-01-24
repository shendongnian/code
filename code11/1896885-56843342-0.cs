public class MultipleBy2Test
{
    private readonly Dictionary<int, int> _values = new Dictionary<int, int>();
    public void AddItem(int originalAmount)
    {
        _values.Add(originalAmount, originalAmount * 2);
    }
}
Now the class doesn't inherit from `Dictionary<int, int>` and nothing in its public interface allows access to the dictionary. Data integrity is ensured because nothing but your method can add anything to the dictionary.
It's unclear whether other classes would need to read from the dictionary. If so you'd need a method for retrieving values as well.
