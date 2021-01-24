    private List<T> Shuffle<T>(List<T> p)
    {
        List<T> result = new List<T>(); // result and p are different lists now
    
        while (p.Count > 0)
        {
            idx = Random.Range(0, p.Count);
    
            print(idx);
            result.Add(p[idx]);  // Now we Add to result only, and Remove from p
            p.RemoveAt(idx);     // <- I suggest removing at index
        }
    
        print("Shuffled");
        return result;
    }
