    var result = foos.Concat(foos.Select(Reverse));
{                               {                               {
"abc",                          "abc",                          "abc",
"def",           =>             "def",           =>             "def",
"ghi",                          "ghi",                          "ghi",
}                               }
                                concat
                                {
                                "cba",                          "cba",
                                "fed",                          "fed",
                                "ihg",                          "ihg",
                                }                               }
