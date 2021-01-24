    var tempColor = "E2270A";
    var m_Red = System.Convert.ToByte(tempColor.Substring(0, 2), 16);
    var m_Green = System.Convert.ToByte(tempColor.Substring(2, 2), 16);
    var m_Blue = System.Convert.ToByte(tempColor.Substring(4, 2), 16);
    var m_NewColor = new UnityEngine.Color32(m_Red, m_Green, m_Blue, 255);
    Animinstance.GetComponent<SpriteRenderer>().color = m_NewColor;
