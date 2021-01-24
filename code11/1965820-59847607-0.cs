public static void FindSandy(params string[] ocean) {
  bool weFuondSandy = false;
  for (int i = 0; i < ocean.Length; i++) {
    if (ocean[i] == "Sandy") {
      weFoundSandy = true;
      break;
    }
  }
  if (weFoundSandy) {
    Console.WriteLine("We found Sandy on position {0}", i);
  } else {
    Console.WriteLine("Sandy was not here");
  }
}
static void Main(string[] args) {
  {
    FindSandy("Bob","Bella", "Sandy", "Nemo", "Dory");
  }
}
