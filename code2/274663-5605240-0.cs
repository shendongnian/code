    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Markup;
    using System.Windows.Media;
    class Program
    {
        public static void Main(String[] args)
        {
            PrintFamiliesSupprotingChar('a');
            Console.ReadLine();
            PrintFamiliesSupprotingChar('â');
            Console.ReadLine();
            PrintFamiliesSupprotingChar('嗎');
            Console.ReadLine();
        }
        private static void PrintFamiliesSupprotingChar(char characterToCheck)
        {
            int count = 0;
            ICollection<FontFamily> fontFamilies = Fonts.GetFontFamilies(@"C:\Windows\Fonts\");
            ushort glyphIndex;
            int unicodeValue = Convert.ToUInt16(characterToCheck);
            GlyphTypeface glyph;
            string familyName;
            foreach (FontFamily family in fontFamilies)
            {
                var typefaces = family.GetTypefaces();
                foreach (Typeface typeface in typefaces)
                {
                    typeface.TryGetGlyphTypeface(out glyph);
                    if (glyph != null && glyph.CharacterToGlyphMap.TryGetValue(unicodeValue, out glyphIndex))
                    {
                        family.FamilyNames.TryGetValue(XmlLanguage.GetLanguage("en-us"), out familyName);
                        Console.WriteLine(familyName + " Supports ");
                        count++;
                        break;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total {0} fonts support {1}", count, characterToCheck);
        }
    }
