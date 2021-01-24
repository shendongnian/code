c#
static bool anyViaAhoCorasick(string[] needles, string haystack)
{
    var trie = new Trie();
    trie.Add(needles);
    trie.Build();
    return trie.Find(haystack).Any();
}
