    class Tester {
        private Semaphore sem = new Semaphore(1, 1);
        public void TestLock() {
            sem.WaitOne();
            for (int i = 0; i < 10; i++) Deadlock(i);
            sem.Release();
        }
        private void Deadlock(int i) {
            if (!sem.WaitOne(100)) Console.WriteLine("deadlock!");
            else {
                sem.Release();
                Console.WriteLine("No deadlock!");
            }
        }
    }
