    Public Function GetMyColour(myColour as integer) as string
    Dim colorObj As System.Drawing.Color = System.Drawing.Color.FromArgb(myColour)
    
    return String.Format("#{0:X2}{1:X2}{2:X2}", colorObj.R, colorObj.G, colorObj.B)
    End Function
