    public class DebugEntry
    {
        public Func<object> m_getValue;
        public Type m_Type;
    ...
    public DebugEntry(Func<object> getValue, string mName, DebugDrawStyle mStyle, float mMin, float mMax)
    {
        m_getValue = getValue;
        m_Type = getValue().GetType();
        m_name = mName;
        m_Style = mStyle;
        m_min = mMin;
        m_max = mMax;
    }
   
    ...
 
    public void AddDebugEntry(Func<object> getValue, string name, DebugDrawStyle style = DebugDrawStyle.Label, float min = 0, float max = 0)
    {
        DebugEntry newEntry = new DebugEntry(getValue, name, style, min, max);
        DebugEntries.Add(newEntry);
    }
    ...
    switch (Type.GetTypeCode(entry.m_Type))
    {
   
    ...
    
    void DrawLabel(DebugEntry entry)
    {
        
        GUI.Label(new Rect(DebugPosition.x, DebugPosition.y + (DebugSize.y * index), DebugSize.x, DebugSize.y), entry.m_name.ToString());
        index++;
        GUI.Label(new Rect(DebugPosition.x, DebugPosition.y + (DebugSize.y * index), DebugSize.x, DebugSize.y), entry.m_getValue().ToString());
    }
    void DrawSlider(DebugEntry entry)
    {
        GUI.Label(new Rect(DebugPosition.x, DebugPosition.y + (DebugSize.y * index), DebugSize.x, DebugSize.y), entry.m_name.ToString());
        index++;
        GUI.HorizontalSlider(new Rect(DebugPosition.x, DebugPosition.y + (DebugSize.y * index), DebugSize.x, DebugSize.y),
            (float) entry.m_getValue(), entry.m_min, entry.m_max);
    }
