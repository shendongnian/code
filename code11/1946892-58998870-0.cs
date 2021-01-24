 C#
var specialModes = new[] { MO.Learn, MO.Practice, MO.Quiz };
if (specialModes.Contains(Settings.Mode) && Settings.Cc == CC.H) {
   Settings.Cc = CC.JLPT5;
   App.cardSetWithWordCount = null;
   App.DB.RemoveSelected();
}
ModeMessage2 = Settings.Mode switch {
   MO.Learn => "Use this mode when you are first learning the phrases and their meanings.",
   MO.Practice => "Use this mode to help you memorize the phrases and their meanings.",
   MO.Quiz => "Use this mode to run a self marked test."
};
if (Settings.Mode == MO.Quiz)
   App.DB.UpdSet(SET.Adp, false);
