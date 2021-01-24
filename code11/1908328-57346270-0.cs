C#
// make regex object, to match class names:
// classnames are preceded by keyword 'class' and space chars or tabs,
// and lasts until : or { (between classname and these characters can be arbitrary
// empty space. Or maybe not, so we use \s* where * determines zero or more occurences.)
var classNames = new Regex(@"class\s+(.+?)\s*[:{]?$", RegexOptions.Compiled); 
// Applying regex on the text and get collection of matches
var matches = classNames.Matches(text);
// Iterate through matches and show MessageBox with name of the class
foreach (Match match in matches){
    MessageBox.Show(match.Groups[1].Value);
}
