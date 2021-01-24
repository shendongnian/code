    public class Map : Button
    {
        // Existing code exluded from this example
        public static Map Parse(string input, int row, int col)
        {
            if (input == null) return null;
            int typeVal;
            if (!int.TryParse(input, out typeVal))
            {
                throw new ArgumentException("input must be a valid integer");
            }
            // Return a new map with row, col, and Type
            return new Map(row, col) {Type = (MapType) typeVal};            
        }
    }
