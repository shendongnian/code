    public FramePath Clone()
        {
            FramePath result = new FramePath();
            result.XpathSegments = XpathSegments.GetRange(0, XpathSegments.Count);
            return result;
        }
