    var root = new Node {
      Name = "Root",
      Children = new[] {
        new Node {
          Name = "A",
          Children = new[] {
            new Node {
              Name = "AA",
              Children = new [] {
                new Node { Name = "AAA" },
                new Node { Name = "AAB" },
                new Node { Name = "AAC" }
              }
            },
            new Node { Name = "AB" },
            new Node { Name = "AC" }
          }
        },
        new Node {
          Name = "B",
          Children = new Node[] {
            new Node { Name = "BA" }
          }
        }
      }
    };
