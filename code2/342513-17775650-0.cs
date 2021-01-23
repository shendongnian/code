    Function RGB2ACIDXFColor(MyColor : TColor) : Integer ;
    Var
       OldCol, LowR, MidR, HiR : String ;
       RCol, GCol, BCol, LowCol, MidCol, HiCol : Integer ;
       StPt, HRatio, VRatio, Hemis : Integer ;
    Begin
    Result := 10 ;
    {Break Color Component (BGR Color)}
    {IntToHex & Hex2Dec are functions from Lazarus Libraries}
    OldCol := IntToHex(MyColor,6) ;    
    BCol := Hex2Dec(Copy(OldCol,1,2)) ;
    GCol := Hex2Dec(Copy(OldCol,3,2)) ;
    RCol := Hex2Dec(Copy(OldCol,5,2)) ;
    
    {Find Color Component Priorities}
    LowCol := RCol ;
    LowR := 'R' ;
    If (GCol < LowCol) Then
    Begin
         LowCol := GCol ;
         LowR := 'G' ;
    End; //If
    If (BCol < LowCol) Then
    Begin
         LowCol := BCol ;
         LowR := 'B' ;
    End; //If
    
    HiCol := RCol ;
    HiR := 'R' ;
    If (GCol > HiCol) Then
    Begin
         HiCol := GCol ;
         HiR := 'G' ;
    End; //If
    If (BCol > HiCol) Then
    Begin
         HiCol := BCol ;
         HiR := 'B' ;
    End; //If
    
    MidCol := GCol ;
    MidR := 'G' ;
    If ((HiR = 'G') AND (LowR = 'R')) OR
       ((HiR = 'R') AND (LowR = 'G')) Then
    Begin
         MidCol := BCol ;
         MidR := 'B' ;
    End; //If
    If ((HiR = 'G') AND (LowR = 'B')) OR
       ((HiR = 'B') AND (LowR = 'G')) Then
    Begin
         MidCol := RCol ;
         MidR := 'R' ;
    End; //If
    
    {Refer to CAD color table}
    {Find Color Row}
    VRatio := FinRound((5 * (255 - HiCol)) Div 255) ;
    VRatio *= 2 ;
    {Find Color Hemisphere}
    If (LowCol = 0) Then Hemis := 0 Else Hemis := 1 ;
    
    {Find Color Start Column And Incrementation}
    If (LowR = 'B') Then
    Begin
         HRatio := FinRound((8 * GCol) Div (GCol + RCol)) ;
         Result := 10 ;
    End; //If
    If (LowR = 'G') Then
    Begin
         HRatio := FinRound((8 * RCol) Div (RCol + BCol)) ;
         Result := 170 ;
    End; //If
    If (LowR = 'R') Then
    Begin
         HRatio := FinRound((8 * BCol) Div (BCol + GCol)) ;
         Result := 90 ;
    End; //If
    
    HRatio *= 10 ;
    Result += HRatio + VRatio + Hemis ;
    If (Result > 249) Then Result -= 240 ;
    End; //Sub
