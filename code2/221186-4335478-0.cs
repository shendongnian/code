    public static void TryToMoveTo(this DirectoryInfo o, string targetPath) {
        int attemptsRemaining = 5;
        while (true) {
            try {
                o.MoveTo(targetPath);
                break;
            } catch (Exception) {
                if (attemptsRemaining == 0) {
                    throw;
                } else {
                    attemptsRemaining--;
                    System.Threading.Thread.Sleep(10);
                }
            }
        }
    }
