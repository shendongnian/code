    Option Strict On
    Option Explicit On
    
    Imports System.Runtime.InteropServices
    
    Public Class Form1
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ''//Create our helper function
            Dim UCR As New UnicodeCharRanges()
    
            ''//Get our ranges for ja-JP
            Dim Ranges = UCR.GetUnicodeRanges("ja-JP")
            If Ranges IsNot Nothing Then
                ''//Get our characters (strings actually)
                Dim Chars = UCR.GetCharactersForUnicodeRanges(Ranges)
                Trace.WriteLine(Chars.Count) ''//28351
    
                ''//Include surrogate pairs as letters. .Net does not have a way to determine if these should be considered letters
                Chars = UCR.GetCharactersForUnicodeRanges(Ranges, True)
                Trace.WriteLine(Chars.Count) ''//71615
            End If
    
            ''//Get our ranges for en-US
            Ranges = UCR.GetUnicodeRanges("en-US")
            If Ranges IsNot Nothing Then
                ''//Get our characters (strings actually)
                Dim Chars = UCR.GetCharactersForUnicodeRanges(Ranges)
                Trace.WriteLine(Chars.Count) ''//117
            End If
    
    
        End Sub
    End Class
    Public Class UnicodeCharRanges
    #Region " Unmanaged "
        <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Private Shared Function GetLocaleInfoW(ByVal locale As Integer, ByVal LCType As Integer, ByRef lpLCData As LOCALESIGNATURE, ByVal cchData As Integer) As Integer
        End Function
        Private LOCALE_FONTSIGNATURE As Integer = &H58
        <StructLayout(LayoutKind.Sequential)>
        Private Structure LOCALESIGNATURE
            <MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=4)> Dim lsUsb() As Integer
            <MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Dim lsCsbDefault() As Integer
            <MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Dim lsCsbSupported() As Integer
            Public Sub Initialize()
                ReDim lsUsb(3)
                ReDim lsCsbDefault(1)
                ReDim lsCsbSupported(1)
            End Sub
        End Structure
    #End Region
    #Region " Locals "
        Private AllRanges As List(Of UnicodeRangeInfo)
    #End Region
        Private Sub LoadRanges()
            ''//Ranges from http://msdn.microsoft.com/en-us/library/dd374090%28VS.85%29.aspx
            AllRanges = New List(Of UnicodeRangeInfo)
            AllRanges.Add(New UnicodeRangeInfo(0, &H0, &H7F, "Basic Latin"))
            AllRanges.Add(New UnicodeRangeInfo(1, &H80, &HFF, "Latin-1 Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(2, &H100, &H17F, "Latin Extended-A"))
            AllRanges.Add(New UnicodeRangeInfo(3, &H180, &H24F, "Latin Extended-B"))
            AllRanges.Add(New UnicodeRangeInfo(4, &H250, &H2AF, "IPA Extensions"))
            AllRanges.Add(New UnicodeRangeInfo(4, &H1D00, &H1D7F, "Phonetic Extensions"))
            AllRanges.Add(New UnicodeRangeInfo(4, &H1D80, &H1DBF, "Phonetic Extensions Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(5, &H2B0, &H2FF, "Spacing Modifier Letters"))
            AllRanges.Add(New UnicodeRangeInfo(5, &HA700, &HA71F, "Modifier Tone Letters"))
            AllRanges.Add(New UnicodeRangeInfo(6, &H300, &H36F, "Combining Diacritical Marks"))
            AllRanges.Add(New UnicodeRangeInfo(6, &H1DC0, &H1DFF, "Combining Diacritical Marks Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(7, &H370, &H3FF, "Greek and Coptic"))
            AllRanges.Add(New UnicodeRangeInfo(8, &H2C80, &H2CFF, "Coptic"))
            AllRanges.Add(New UnicodeRangeInfo(9, &H400, &H4FF, "Cyrillic"))
            AllRanges.Add(New UnicodeRangeInfo(9, &H500, &H52F, "Cyrillic Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(9, &H2DE0, &H2DFF, "Cyrillic Extended-A"))
            AllRanges.Add(New UnicodeRangeInfo(9, &HA640, &HA69F, "Cyrillic Extended-B"))
            AllRanges.Add(New UnicodeRangeInfo(10, &H530, &H58F, "Armenian"))
            AllRanges.Add(New UnicodeRangeInfo(11, &H590, &H5FF, "Hebrew"))
            AllRanges.Add(New UnicodeRangeInfo(12, &HA500, &HA63F, "&hVai"))
            AllRanges.Add(New UnicodeRangeInfo(13, &H600, &H6FF, "Arabic"))
            AllRanges.Add(New UnicodeRangeInfo(13, &H750, &H77F, "Arabic Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(14, &H7C0, &H7FF, "NKo"))
            AllRanges.Add(New UnicodeRangeInfo(15, &H900, &H97F, "Devanagari"))
            AllRanges.Add(New UnicodeRangeInfo(16, &H980, &H9FF, "Bengali"))
            AllRanges.Add(New UnicodeRangeInfo(17, &HA00, &HA7F, "Gurmukhi"))
            AllRanges.Add(New UnicodeRangeInfo(18, &HA80, &HAFF, "Gujarati"))
            AllRanges.Add(New UnicodeRangeInfo(19, &HB00, &HB7F, "Oriya"))
            AllRanges.Add(New UnicodeRangeInfo(20, &HB80, &HBFF, "Tamil"))
            AllRanges.Add(New UnicodeRangeInfo(21, &HC00, &HC7F, "Telugu"))
            AllRanges.Add(New UnicodeRangeInfo(22, &HC80, &HCFF, "Kannada"))
            AllRanges.Add(New UnicodeRangeInfo(23, &HD00, &HD7F, "Malayalam"))
            AllRanges.Add(New UnicodeRangeInfo(24, &HE00, &HE7F, "Thai"))
            AllRanges.Add(New UnicodeRangeInfo(25, &HE80, &HEFF, "Lao"))
            AllRanges.Add(New UnicodeRangeInfo(26, &H10A0, &H10FF, "Georgian"))
            AllRanges.Add(New UnicodeRangeInfo(26, &H2D00, &H2D2F, "Georgian Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(27, &H1B00, &H1B7F, "Balinese"))
            AllRanges.Add(New UnicodeRangeInfo(28, &H1100, &H11FF, "Hangul Jamo"))
            AllRanges.Add(New UnicodeRangeInfo(29, &H1E00, &H1EFF, "Latin Extended Additional"))
            AllRanges.Add(New UnicodeRangeInfo(29, &H2C60, &H2C7F, "Latin Extended-C"))
            AllRanges.Add(New UnicodeRangeInfo(29, &HA720, &HA7FF, "Latin Extended-D"))
            AllRanges.Add(New UnicodeRangeInfo(30, &H1F00, &H1FFF, "Greek Extended"))
            AllRanges.Add(New UnicodeRangeInfo(31, &H2000, &H206F, "General Punctuation"))
            AllRanges.Add(New UnicodeRangeInfo(31, &H2E00, &H2E7F, "Supplemental Punctuation"))
            AllRanges.Add(New UnicodeRangeInfo(32, &H2070, &H209F, "Superscripts And Subscripts"))
            AllRanges.Add(New UnicodeRangeInfo(33, &H20A0, &H20CF, "Currency Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(34, &H20D0, &H20FF, "Combining Diacritical Marks For Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(35, &H2100, &H214F, "Letterlike Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(36, &H2150, &H218F, "Number Forms"))
            AllRanges.Add(New UnicodeRangeInfo(37, &H2190, &H21FF, "Arrows"))
            AllRanges.Add(New UnicodeRangeInfo(37, &H27F0, &H27FF, "Supplemental Arrows-A"))
            AllRanges.Add(New UnicodeRangeInfo(37, &H2900, &H297F, "Supplemental Arrows-B"))
            AllRanges.Add(New UnicodeRangeInfo(37, &H2B00, &H2BFF, "Miscellaneous Symbols and Arrows"))
            AllRanges.Add(New UnicodeRangeInfo(38, &H2200, &H22FF, "Mathematical Operators"))
            AllRanges.Add(New UnicodeRangeInfo(38, &H27C0, &H27EF, "Miscellaneous Mathematical Symbols-A"))
            AllRanges.Add(New UnicodeRangeInfo(38, &H2980, &H29FF, "Miscellaneous Mathematical Symbols-B"))
            AllRanges.Add(New UnicodeRangeInfo(38, &H2A00, &H2AFF, "Supplemental Mathematical Operators"))
            AllRanges.Add(New UnicodeRangeInfo(39, &H2300, &H23FF, "Miscellaneous Technical"))
            AllRanges.Add(New UnicodeRangeInfo(40, &H2400, &H243F, "Control Pictures"))
            AllRanges.Add(New UnicodeRangeInfo(41, &H2440, &H245F, "Optical Character Recognition"))
            AllRanges.Add(New UnicodeRangeInfo(42, &H2460, &H24FF, "Enclosed Alphanumerics"))
            AllRanges.Add(New UnicodeRangeInfo(43, &H2500, &H257F, "Box Drawing"))
            AllRanges.Add(New UnicodeRangeInfo(44, &H2580, &H259F, "Block Elements"))
            AllRanges.Add(New UnicodeRangeInfo(45, &H25A0, &H25FF, "Geometric Shapes"))
            AllRanges.Add(New UnicodeRangeInfo(46, &H2600, &H26FF, "Miscellaneous Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(47, &H2700, &H27BF, "Dingbats"))
            AllRanges.Add(New UnicodeRangeInfo(48, &H3000, &H303F, "CJK Symbols And Punctuation"))
            AllRanges.Add(New UnicodeRangeInfo(49, &H3040, &H309F, "Hiragana"))
            AllRanges.Add(New UnicodeRangeInfo(50, &H30A0, &H30FF, "Katakana"))
            AllRanges.Add(New UnicodeRangeInfo(50, &H31F0, &H31FF, "Katakana Phonetic Extensions"))
            AllRanges.Add(New UnicodeRangeInfo(51, &H3100, &H312F, "Bopomofo"))
            AllRanges.Add(New UnicodeRangeInfo(51, &H31A0, &H31BF, "Bopomofo Extended"))
            AllRanges.Add(New UnicodeRangeInfo(52, &H3130, &H318F, "Hangul Compatibility Jamo"))
            AllRanges.Add(New UnicodeRangeInfo(53, &HA840, &HA87F, "Phags-pa"))
            AllRanges.Add(New UnicodeRangeInfo(54, &H3200, &H32FF, "Enclosed CJK Letters And Months"))
            AllRanges.Add(New UnicodeRangeInfo(55, &H3300, &H33FF, "CJK Compatibility"))
            AllRanges.Add(New UnicodeRangeInfo(56, &HAC00, &HD7AF, "Hangul Syllables"))
            AllRanges.Add(New UnicodeRangeInfo(57, &HD800, &HDFFF, "Non-Plane 0. Note that setting this bit implies that there is at least one supplementary code point beyond the Basic Multilingual Plane (BMP) that is supported by this font. See Surrogates and Supplementary Characters."))
            AllRanges.Add(New UnicodeRangeInfo(58, &H10900, &H1091F, "Phoenician"))
            AllRanges.Add(New UnicodeRangeInfo(59, &H2E80, &H2EFF, "CJK Radicals Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(59, &H2F00, &H2FDF, "Kangxi Radicals"))
            AllRanges.Add(New UnicodeRangeInfo(59, &H2FF0, &H2FFF, "Ideographic Description Characters"))
            AllRanges.Add(New UnicodeRangeInfo(59, &H3190, &H319F, "Kanbun"))
            AllRanges.Add(New UnicodeRangeInfo(59, &H3400, &H4DBF, "CJK Unified Ideographs Extension A"))
            AllRanges.Add(New UnicodeRangeInfo(59, &H4E00, &H9FFF, "CJK Unified Ideographs"))
            AllRanges.Add(New UnicodeRangeInfo(59, &H20000, &H2A6DF, "CJK Unified Ideographs Extension B"))
            AllRanges.Add(New UnicodeRangeInfo(60, &HE000, &HF8FF, "Private Use Area"))
            AllRanges.Add(New UnicodeRangeInfo(61, &H31C0, &H31EF, "CJK Strokes"))
            AllRanges.Add(New UnicodeRangeInfo(61, &HF900, &HFAFF, "CJK Compatibility Ideographs"))
            AllRanges.Add(New UnicodeRangeInfo(61, &H2F800, &H2FA1F, "CJK Compatibility Ideographs Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(62, &HFB00, &HFB4F, "Alphabetic Presentation Forms"))
            AllRanges.Add(New UnicodeRangeInfo(63, &HFB50, &HFDFF, "Arabic Presentation Forms-A"))
            AllRanges.Add(New UnicodeRangeInfo(64, &HFE20, &HFE2F, "Combining Half Marks"))
            AllRanges.Add(New UnicodeRangeInfo(65, &HFE10, &HFE1F, "Vertical Forms"))
            AllRanges.Add(New UnicodeRangeInfo(65, &HFE30, &HFE4F, "CJK Compatibility Forms"))
            AllRanges.Add(New UnicodeRangeInfo(66, &HFE50, &HFE6F, "Small Form Variants"))
            AllRanges.Add(New UnicodeRangeInfo(67, &HFE70, &HFEFF, "Arabic Presentation Forms-B"))
            AllRanges.Add(New UnicodeRangeInfo(68, &HFF00, &HFFEF, "Halfwidth And Fullwidth Forms"))
            AllRanges.Add(New UnicodeRangeInfo(69, &HFFF0, &HFFFF, "Specials"))
            AllRanges.Add(New UnicodeRangeInfo(70, &HF00, &HFFF, "Tibetan"))
            AllRanges.Add(New UnicodeRangeInfo(71, &H700, &H74F, "Syriac"))
            AllRanges.Add(New UnicodeRangeInfo(72, &H780, &H7BF, "Thaana"))
            AllRanges.Add(New UnicodeRangeInfo(73, &HD80, &HDFF, "Sinhala"))
            AllRanges.Add(New UnicodeRangeInfo(74, &H1000, &H109F, "Myanmar"))
            AllRanges.Add(New UnicodeRangeInfo(75, &H1200, &H137F, "Ethiopic"))
            AllRanges.Add(New UnicodeRangeInfo(75, &H1380, &H139F, "Ethiopic Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(75, &H2D80, &H2DDF, "Ethiopic Extended"))
            AllRanges.Add(New UnicodeRangeInfo(76, &H13A0, &H13FF, "Cherokee"))
            AllRanges.Add(New UnicodeRangeInfo(77, &H1400, &H167F, "Unified Canadian Aboriginal Syllabics"))
            AllRanges.Add(New UnicodeRangeInfo(78, &H1680, &H169F, "Ogham"))
            AllRanges.Add(New UnicodeRangeInfo(79, &H16A0, &H16FF, "Runic"))
            AllRanges.Add(New UnicodeRangeInfo(80, &H1780, &H17FF, "Khmer"))
            AllRanges.Add(New UnicodeRangeInfo(80, &H19E0, &H19FF, "Khmer Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(81, &H1800, &H18AF, "Mongolian"))
            AllRanges.Add(New UnicodeRangeInfo(82, &H2800, &H28FF, "Braille Patterns"))
            AllRanges.Add(New UnicodeRangeInfo(83, &HA000, &HA48F, "Yi Syllables"))
            AllRanges.Add(New UnicodeRangeInfo(83, &HA490, &HA4CF, "Yi Radicals"))
            AllRanges.Add(New UnicodeRangeInfo(84, &H1700, &H171F, "Tagalog"))
            AllRanges.Add(New UnicodeRangeInfo(84, &H1720, &H173F, "Hanunoo"))
            AllRanges.Add(New UnicodeRangeInfo(84, &H1740, &H175F, "Buhid"))
            AllRanges.Add(New UnicodeRangeInfo(84, &H1760, &H177F, "Tagbanwa"))
            AllRanges.Add(New UnicodeRangeInfo(85, &H10300, &H1032F, "Old Italic"))
            AllRanges.Add(New UnicodeRangeInfo(86, &H10330, &H1034F, "Gothic"))
            AllRanges.Add(New UnicodeRangeInfo(87, &H10400, &H1044F, "Deseret"))
            AllRanges.Add(New UnicodeRangeInfo(88, &H1D000, &H1D0FF, "Byzantine Musical Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(88, &H1D100, &H1D1FF, "Musical Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(88, &H1D200, &H1D24F, "Ancient Greek Musical Notation"))
            AllRanges.Add(New UnicodeRangeInfo(89, &H1D400, &H1D7FF, "Mathematical Alphanumeric Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(90, &HFF000, &HFFFFD, "Private Use (plane 15)"))
            AllRanges.Add(New UnicodeRangeInfo(90, &H100000, &H10FFFD, "Private Use (plane 16)"))
            AllRanges.Add(New UnicodeRangeInfo(91, &HFE00, &HFE0F, "Variation Selectors"))
            AllRanges.Add(New UnicodeRangeInfo(91, &HE0100, &HE01EF, "Variation Selectors Supplement"))
            AllRanges.Add(New UnicodeRangeInfo(92, &HE0000, &HE007F, "Tags"))
            AllRanges.Add(New UnicodeRangeInfo(93, &H1900, &H194F, "Limbu"))
            AllRanges.Add(New UnicodeRangeInfo(94, &H1950, &H197F, "Tai Le"))
            AllRanges.Add(New UnicodeRangeInfo(95, &H1980, &H19DF, "New Tai Lue"))
            AllRanges.Add(New UnicodeRangeInfo(96, &H1A00, &H1A1F, "Buginese"))
            AllRanges.Add(New UnicodeRangeInfo(97, &H2C00, &H2C5F, "Glagolitic"))
            AllRanges.Add(New UnicodeRangeInfo(98, &H2D30, &H2D7F, "Tifinagh"))
            AllRanges.Add(New UnicodeRangeInfo(99, &H4DC0, &H4DFF, "Yijing Hexagram Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(100, &HA800, &HA82F, "Syloti Nagri"))
            AllRanges.Add(New UnicodeRangeInfo(101, &H10000, &H1007F, "Linear B Syllabary"))
            AllRanges.Add(New UnicodeRangeInfo(101, &H10080, &H100FF, "Linear B Ideograms"))
            AllRanges.Add(New UnicodeRangeInfo(101, &H10100, &H1013F, "Aegean Numbers"))
            AllRanges.Add(New UnicodeRangeInfo(102, &H10140, &H1018F, "Ancient Greek Numbers"))
            AllRanges.Add(New UnicodeRangeInfo(103, &H10380, &H1039F, "Ugaritic"))
            AllRanges.Add(New UnicodeRangeInfo(104, &H103A0, &H103DF, "Old Persian"))
            AllRanges.Add(New UnicodeRangeInfo(105, &H10450, &H1047F, "Shavian"))
            AllRanges.Add(New UnicodeRangeInfo(106, &H10480, &H104AF, "Osmanya"))
            AllRanges.Add(New UnicodeRangeInfo(107, &H10800, &H1083F, "Cypriot Syllabary"))
            AllRanges.Add(New UnicodeRangeInfo(108, &H10A00, &H10A5F, "Kharoshthi"))
            AllRanges.Add(New UnicodeRangeInfo(109, &H1D300, &H1D35F, "Tai Xuan Jing Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(110, &H12000, &H123FF, "Cuneiform"))
            AllRanges.Add(New UnicodeRangeInfo(110, &H12400, &H1247F, "Cuneiform Numbers and Punctuation"))
            AllRanges.Add(New UnicodeRangeInfo(111, &H1D360, &H1D37F, "Counting Rod Numerals"))
            AllRanges.Add(New UnicodeRangeInfo(112, &H1B80, &H1BBF, "Sundanese"))
            AllRanges.Add(New UnicodeRangeInfo(113, &H1C00, &H1C4F, "Lepcha"))
            AllRanges.Add(New UnicodeRangeInfo(114, &H1C50, &H1C7F, "Ol Chiki"))
            AllRanges.Add(New UnicodeRangeInfo(115, &HA880, &HA8DF, "Saurashtra"))
            AllRanges.Add(New UnicodeRangeInfo(116, &HA900, &HA92F, "Kayah Li"))
            AllRanges.Add(New UnicodeRangeInfo(117, &HA930, &HA95F, "Rejang"))
            AllRanges.Add(New UnicodeRangeInfo(118, &HAA00, &HAA5F, "Cham"))
            AllRanges.Add(New UnicodeRangeInfo(119, &H10190, &H101CF, "hAncient Symbols"))
            AllRanges.Add(New UnicodeRangeInfo(120, &H101D0, &H101FF, "Phaistos Disc"))
            AllRanges.Add(New UnicodeRangeInfo(121, &H10280, &H1029F, "Lycian"))
            AllRanges.Add(New UnicodeRangeInfo(121, &H102A0, &H102DF, "Carian"))
            AllRanges.Add(New UnicodeRangeInfo(121, &H10920, &H1093F, "Lydian"))
            AllRanges.Add(New UnicodeRangeInfo(122, &H1F000, &H1F02F, "Mahjong Tiles"))
            AllRanges.Add(New UnicodeRangeInfo(122, &H1F030, &H1F09F, "Domino Tiles"))
        End Sub
        Sub New()
            LoadRanges()
        End Sub
        Public Function GetCharactersForUnicodeRanges(ByVal ranges As List(Of UnicodeRangeInfo), Optional ByVal returnSurrogatePairs As Boolean = False) As List(Of String)
            ''//The Char structure cannot represent all Unicode characters so we need to return strings. See "Surrogate pairs" at the bottom of http://www.yoda.arachsys.com/csharp/unicode.html
            Dim Ret As New List(Of String)
            Dim S As String
            Dim C As Char
            ''//Loop through all of the ranges
            For Each R In ranges
                ''//Loop from start to end
                For I = R.StartRange To R.EndRange
                    ''//Convert the integer to either a char or a surrogate pair string
                    S = Char.ConvertFromUtf32(I)
                    ''//See if the character is a valid Char
                    If Char.TryParse(S, C) Then
                        ''//See if the Char is a letter
                        If Char.IsLetter(C) Then Ret.Add(C)
                    ElseIf returnSurrogatePairs Then
                        ''//If asked to also return surrogate pairs then do so
                        Ret.Add(S)
                    End If
                Next
            Next
    
            Return Ret
        End Function
        Public Function GetUnicodeRanges(ByVal cultureName As String) As List(Of UnicodeRangeInfo)
            ''//Get the culture info for the given locale
            Dim CI As New System.Globalization.CultureInfo(cultureName)
    
            ''//Create and init our structure that will get passed
            Dim FI As New LOCALESIGNATURE()
            FI.Initialize()
    
            ''//Determine the size of our structure
            Dim SI = Marshal.SizeOf(FI)
    
            ''//Call the unmanaged function
            Dim Result As Integer = GetLocaleInfoW(CI.LCID, LOCALE_FONTSIGNATURE, FI, SI)
            If Result = 0 Then
                ''//If we get a zero then there's an error. This should call GetLastError ideally
                Return Nothing
            Else
                ''//The lsUsb field represents a 128 bit value but we pass it into the unmanaged function as an array of 4 integers.
                ''//The code below converts the array of integers to a giant binary string.
                ''//There are of course better ways to do this that will save 5ms but I will leave that to you
                Dim Usb = StrReverse(String.Format("{0}{1}{2}{3}",
                                                   Convert.ToString(FI.lsUsb(3), 2).PadLeft(32, "0"c),
                                                   Convert.ToString(FI.lsUsb(2), 2).PadLeft(32, "0"c),
                                                   Convert.ToString(FI.lsUsb(1), 2).PadLeft(32, "0"c),
                                                   Convert.ToString(FI.lsUsb(0), 2).PadLeft(32, "0"c)))
    
                ''//This will be our return ranges
                Dim LocaleRanges As New List(Of UnicodeRangeInfo)
    
                Dim loopI As Integer
    
                ''//Loop through the bits
                ''//Technically the last couple of bits aren't supposed to be used but there is no value in UnicodeRangeInfo for them anyway so it does not matter
                For I = 0 To (Usb.Length - 1)
                    ''//This is to stop the compiler complaining about lambda expressions
                    loopI = I
    
                    ''//If the bit is set
                    If Usb(I) = "1"c Then
                        ''//Find all ranges in the master range list with that bit set
                        LocaleRanges.AddRange(AllRanges.FindAll(Function(n) n.Bit = loopI))
                    End If
                Next
                Return LocaleRanges
            End If
        End Function
    
        Public Structure UnicodeRangeInfo
            Public Property Name As String
            Public Property StartRange As Integer
            Public Property EndRange As Integer
            Public Property Bit As Integer
            Public Sub New(ByVal bit As Integer, ByVal startRange As Integer, ByVal endRange As Integer, ByVal name As String)
                Me.Bit = bit
                Me.StartRange = startRange
                Me.EndRange = endRange
                Me.Name = name
            End Sub
            Public Overrides Function ToString() As String
                Return String.Format("{0}-{1} : {2}", Convert.ToString(Me.StartRange, 16).PadLeft(8, "0"c), Convert.ToString(Me.EndRange, 16).PadLeft(8, "0"c), Me.Name)
            End Function
        End Structure
    End Class
