static bool findWord()
{
 var text = @"“Under the guise of Medicare for All and a Green New Deal, Democrats are embracing the same tired economic theories that have impoverished nations and stifled the liberties of millions over the past century,” Pence said to applause. “That system is socialism.
“And the only thing green about the so-called Green New Deal is how much green it’s going to cost taxpayers if we do it: $90 million,” he said. Democrats have said the price tag would be lower than the figure Pence quoted.
His comments to the Conservative Political Action Conference outside Washington continued a White House and Republican National Committee push to paint the opposition party as hellbent on making America’s economy one that is centrally planned from Washington and intent on taking money out of Americans’ pockets to finance a myriad social programs.";
      
var stringList = text.Split(' ', ',', ':', '.', '?', '“', '-'); // split the text into pieces and make a list
foreach (var word in stringList) // go through all items of that list
{
  if (word == "nation") return true;       
}
return false;
}
