    switch (status)
                {
                    case Somestatus.Enum1:
                        DoE();
                        goto SomeStatus.Enum2;
                    case Somestatus.Enum2:
                        DoD();
                        goto SomeStatus.Enum3;
                    case Somestatus.Enum3:
                        DoC();
                        goto SomeStatus.Enum4;
                    case Somestatus.Enum4:
                        DoB();
                        goto SomeStatus.Enum5;
                    case Somestatus.Enum5:
                        DoA();
                }
