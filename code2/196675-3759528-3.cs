    internal int ReadUntil(int index)
    {
        int count = this.list.Count;
        while (!this.done && (count <= index))
        {
            if (this.nodeIterator.MoveNext())
            {
                XmlNode item = this.GetNode(this.nodeIterator.Current);
                if (item != null)
                {
                    this.list.Add(item);
                    count++;
                }
            }
            else
            {
                this.done = true;
                return count;
            }
        }
        return count;
    }
