C#
using System;
class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine ("Value of " + Modes.ModeC + " is " + (byte)Modes.ModeC);
  }
  public enum Modes {
    ModeA = 0x01,
    ModeB = 0x03,
    ModeC = 0x05
  }
}
