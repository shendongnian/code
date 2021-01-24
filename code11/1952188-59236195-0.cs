if (other.transform.tag == "projetil")
        {
            if (SpawnProjetil1.tag == "Spaw1")//right
            {
                GameObject tiro = Instantiate(Projetil, SpawnProjetil1.transform.position, SpawnProjetil1.transform.rotation);
                Rigidbody rigiProj = tiro.GetComponent<Rigidbody>();
                rigiProj.velocity = SpawnProjetil1.transform.forward * ProjetVelocity * Time.deltaTime;
            }
            if (SpawnProjetil2.tag == "Spaw2")//left
            {
                GameObject tiro = Instantiate(Projetil, SpawnProjetil2.transform.position, SpawnProjetil2.transform.rotation);
                Rigidbody rigiProj = tiro.GetComponent<Rigidbody>();
                rigiProj.velocity = SpawnProjetil2.transform.forward * ProjetVelocity * Time.deltaTime;
            }
            if (SpawnProjetil3.tag == "Spaw3")//behind
            {
                GameObject tiro = Instantiate(Projetil, SpawnProjetil3.transform.position, SpawnProjetil3.transform.rotation);
                Rigidbody rigiProj = tiro.GetComponent<Rigidbody>();
                rigiProj.velocity = SpawnProjetil3.transform.forward * ProjetVelocity * Time.deltaTime;
            }
            if (SpawnProjetil4.tag == "Spaw4")//front
            {
                GameObject tiro = Instantiate(Projetil, SpawnProjetil4.transform.position, SpawnProjetil4.transform.rotation);
                Rigidbody rigiProj = tiro.GetComponent<Rigidbody>();
                rigiProj.velocity = SpawnProjetil4.transform.forward * ProjetVelocity * Time.deltaTime;
            }
            Destroy(other.gameObject);
        }
