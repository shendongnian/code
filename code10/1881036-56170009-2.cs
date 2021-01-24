    const regex = /(<p>)([\s\S]*?)(<\/p>)/gm;
    const str = `<p>
    <st>Liebe stern-Redaktion,
    </st> 
    <i>Liebe stern-Redaktion,</i> warum schreiben Sie nicht, was wirklich freitags whrend der Protest-Demos am Grenzzaun passiert? Wie die Familien der Mrder fr jede gettete jdische Person belohnt werden? Oder ber die Feuerballons, die aus dem Gazastreifen in den Sden Israels geschickt werden? Brita Singh, Scheeel</p>
    <fig>
    <img src="images/img_8-1.jpg" width="596" height="428" alt="" />
    <fc>
    <i>stern</i> Nr. 10/2019, Bild der Woche: Kindertrauer im Gazastreifen</fc>
    </fig>	
    <p>
    <i>Sehr geehrte Frau Singh,</i> bei Demonstrationen am Grenzzaun starben laut Bericht der UN-Kommission in neun Monaten 35 Kinder durch Schüsse israelischer Soldaten. Zwei Journalisten und drei Sanitäter wurden erschossen, über 6000 Menschen verletzt. Israel hat gerade Ermittlungen zu elf der Todesfälle aufgenommen. Dagegen hat es in dem Zeitraum kein israelisches Todesopfer am Grenzzaun zu Gaza gegeben. Die Hamas pflegt einen Märtyrerkult und belohnt Morde mit Geld; israelische Sicherheitskräfte zerstören Häuser von Angehörigen palästinensischer Attentäter. Beides fördert den Hass. Opfer sind Menschen wie das Mädchen auf diesem Bild. Der <i>stern</i> hat keinen einseitigen Blick auf die Komplexität des Nahostkonflikts wir schauen stets auf beide Seiten. <i>Mit freundlichen Grüßen Cornelia Fuchs, Ressortleiterin Ausland</i></p>
    <p>Eine liebevolle Mutter will, dass ihr Kind glücklich ist, egal, ob sie sein Leben versteht. Alles andere ist Egoismus und keine Mutterliebe. </p>
    <p>Annemarie Fischer, Wielenbach</p>`;
    let m;
    while ((m = regex.exec(str)) !== null) {
        // This is necessary to avoid infinite loops with zero-width matches
        if (m.index === regex.lastIndex) {
            regex.lastIndex++;
        }
        
        // The result can be accessed through the `m`-variable.
        m.forEach((match, groupIndex) => {
            console.log(`Found match, group ${groupIndex}: ${match}`);
        });
    }
