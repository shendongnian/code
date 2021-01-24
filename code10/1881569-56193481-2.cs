        public void RestoreHealth() {
          if (health >= MaxHealth) return; // health and MaxHealth are Class variables
          if (health % 10 != 0) {     // if health is not dividable by 10
            int temp = health % 10; // then we round it to the closest tenth
            temp = 10 - temp;
            health += temp;
          }
          int i = health;
          for (; i < MaxHealth; i += 10) {  // where the health grows till 100
              health += 10 * 1 * time.deltaTime;
              Debug.Log("Health: " + health);
              timer = timerReset;
            
          }
        }
