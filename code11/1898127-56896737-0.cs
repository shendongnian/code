    string tempColor;
    tempColor = "E2270A";
    Color m_NewColor;
    float m_Red, m_Green, m_Blue;
    m_Red = System.Convert.ToSingle (tempColor.Substring (0, 2), 16) / 255.0f;
    m_Green = System.Convert.ToSingle (tempColor.Substring (2, 2), 16) / 255.0f;
    m_Blue = System.Convert.ToSingle (tempColor.Substring (4, 2), 16) / 255.0f;
    m_NewColor = new Color (m_Red, m_Green, m_Blue);
    Animinstance.GetComponent<SpriteRenderer> ().color = m_NewColor;
