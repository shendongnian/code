    public class CellSetConverter : JsonConverter
    {
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(CellSet))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            CellSet cellSet = (CellSet)value;
            int cellCount = cellSet.Cells.Count;
            int[] axisCounts = new int[cellSet.Axes.Count];
            int[] currentIndex = new int[cellSet.Axes.Count];
            for (int i = 0; i < axisCounts.Length; i++)
            {
                axisCounts[i] = cellSet.Axes[i].Positions.Count;
            }
            for (int i = 0; i < cellSet.Axes.Count; i++)
            {
                writer.WriteStartArray();
            }
            for (int i = 0; i < cellCount; i++)
            {
                serializer.Serialize(writer, cellSet[currentIndex].Value);
                currentIndex = IncrementIndex(writer, currentIndex, axisCounts);
            }
        }
        string[] GetCaptions(CellSet cellSet, int[] index)
        {
            string[] captions = new string[index.Length];
            for (int i = 0; i < index.Length; i++)
            {
                Axis axis = cellSet.Axes[i];
                captions[i] = axis.Positions[index[i]].Members[0].Caption;
            }
            return captions;
        }
        int[] IncrementIndex(JsonWriter writer, int[] index, int[] maxSizes)
        {
            bool incremented = false;
            int currentAxis = 0;
            while (!incremented)
            {
                if (index[currentAxis] + 1 == maxSizes[currentAxis])
                {
                    writer.WriteEndArray();
                    index[currentAxis] = 0;
                    currentAxis++;
                }
                else
                {
                    for (int i = 0; i < currentAxis; i++)
                    {
                        writer.WriteStartArray();
                    }
                    index[currentAxis]++;
                    incremented = true;
                }
                if (currentAxis == index.Length)
                {
                    return null;
                }
            }
            return index;
        }
    }
