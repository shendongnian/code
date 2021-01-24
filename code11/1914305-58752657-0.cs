    var client = new GraphQLClient("https://api.github.com/graphql");
    client.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");
    client.DefaultRequestHeaders.Add("User-Agent", userLogin );
    var result = await client.PostQueryAsync(@"{
      repositoryOwner(login: """ + userLogin + @""") {
        repositories(first: 99) {
          nodes {
            name
            rootFolder: object(expression: ""master:"") {
              id
              ... on Tree {
                entries {
                  name
                  object {
                    ... on Blob {
                      byteSize
                    }
                  }
                }
              }
            }
          }
        }
      }
    }");
