    D = device;
    siblings = {};
    while (D has parent) {
        P = parent(D);
        siblings = siblings union (children(P) \ D);
        D = P;
    }
    return descendants(siblings);
